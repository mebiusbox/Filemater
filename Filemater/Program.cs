/*
 * Copyright (c) 2018 mebiusbox software. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Filemater
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Global.LogFileName = "Filemater" + DateTime.Now.ToString("yyyyMMddhh_mmss") + ".log";
            Global.LogFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Filemater.log");

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    //Global.WriteLine("args: " + args[i]);

                    if (args[i].StartsWith("@"))
                    {
                        System.IO.StreamReader reader = new System.IO.StreamReader(args[i].Substring(1), System.Text.Encoding.UTF8);
                        while (!reader.EndOfStream)
                        {
                            Global.Arguments.Add(reader.ReadLine());
                        }
                        reader.Close();

                        Global.ResponseFiles.Add(args[i].Substring(1));
                    }
                    else if (args[i].StartsWith("-autorun"))
                    {
                        Global.AutoRun = true;
                    }
                    else if (args[i].StartsWith("-f"))
                    {
                        Global.DocumentName = args[i].Substring(2);
                    }
                    else if (args[i].StartsWith("-l"))
                    {
                        DateTime dt = DateTime.Now;
                        Global.LogFileName = args[i].Substring(2);
                        Global.LogFileName = Global.LogFileName.Replace("$Time", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                    }
                    else
                    {
                        Global.Arguments.Add(args[i]);
                    }
                }

#if DEBUG
                string pname = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "debug.log");
                System.IO.StreamWriter writer = new System.IO.StreamWriter(pname, false, System.Text.Encoding.UTF8);
                foreach (string arg in args)
                {
                    writer.WriteLine(arg);
                }
                writer.Close();
#endif
            }

            Filemater app = new Filemater();
            Application.Idle += new EventHandler(app.Application_Idle);
            Application.Run(app);
            Application.Idle -= new EventHandler(app.Application_Idle);

            if (Global.AutoRun)
            {
                Global.WriteLine("レスポンスファイルを削除します");
            }

            foreach (string file in Global.ResponseFiles)
            {
                System.IO.File.Delete(file);
            }

            if (Global.AutoRun)
            {
                Global.WriteLine("終了します");
            }
        }
    }
}