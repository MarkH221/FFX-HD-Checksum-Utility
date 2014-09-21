using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FFX
{
    internal static class Program
    {
        private static readonly UInt32[] EndOffset = { 0x64f8, 0x1626C };
        private static byte[] Buffer;
        private static EGame Game;
        internal static string Filepath;
        internal static byte[] Sum;

        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        private static void Main()
        {
            IList<string> args = Environment.GetCommandLineArgs();
            if (((ICollection)args).Count > 1 && File.Exists(args[1]))
            {
                Filepath = args[1];
                BuildBuffer();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        internal static void BuildBuffer()
        {
            try
            {
                using (var fs = new FileStream(Filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //FFX2 saves are significantly larger than X, so we can measure the save to know which is which.
                    Game = (EGame)Convert.ToInt16(fs.Length > 0x68F9);
                    Buffer = new Byte[EndOffset[(int)Game] - 0x40];
                    fs.Position = 0x40;
                    for (int i = 0; i < Buffer.Length; i++)
                    {
                        Buffer[i] = (byte)fs.ReadByte();
                    }
                }
                //Wipe old checksum inside checksum'd block
                Buffer[Buffer.Length - 4] = 0;
                Buffer[Buffer.Length - 3] = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            Compute();
        }

        private static void Compute()
        {
            try
            {
                CrcAlgorithm Hash = new Crc16_CCITT();
                Sum = Hash.ComputeHash(Buffer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            Fix();
        }

        private static void Fix()
        {
            try
            {
                using (var stream = new FileStream(Filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Position = 0x1a;
                    stream.WriteByte(Sum[1]);
                    stream.WriteByte(Sum[0]);
                    stream.Position = EndOffset[(int)Game] - 4;
                    stream.WriteByte(Sum[1]);
                    stream.WriteByte(Sum[0]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private enum EGame
        {
            FFX,
            FFX2
        }
    }
}