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
using System.Text;

namespace Filemater
{
    public class Global
    {
        #region Attributes

        public static Filemater MainForm = null;
        public static List<File> Results = new List<File>();
        public static List<string> Arguments = new List<string>();
        public static List<string> ResponseFiles = new List<string>();
        public static string DocumentName = "";
        public static string LogFileName = "";
        public static bool AutoRun = false;
        public static bool AutoRunExec = false;
        public static EventHandler ClearResultEvent;
        public static EventHandler UpdateResultEvent;
        public static FocusResultItemHandler FocusResultItemEvent;
        public static EventHandler NewDocumentEvent;
        public static EventHandler OpenDocumentEvent;
        public static EventHandler SaveDocumentEvent;
        public static EventHandler ModifyDocumentEvent;

        #endregion Attributes

        #region Public Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void RaiseEvent(EventHandler e)
        {
            if (e != null)
            {
                e(null, new EventArgs());
            }
        }

        public static void ClearResult()
        {
            RaiseClearResultEvent(null);
            Results.Clear();
        }

        public static void RaiseClearResultEvent(object sender)
        {
            if (ClearResultEvent != null)
            {
                ClearResultEvent(sender, new EventArgs());
            }
        }

        public static void RaiseUpdateResultEvent(object sender)
        {
            if (UpdateResultEvent != null)
            {
                UpdateResultEvent(sender, new EventArgs());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class FocusResultItemEventArgs
        {
            public File File = null;

            public FocusResultItemEventArgs(File file)
            {
                this.File = file;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public delegate void FocusResultItemHandler(FocusResultItemEventArgs args);

        public static void RaiseFocusResultItemEvent(File focusItem)
        {
            if (FocusResultItemEvent != null)
            {
                FocusResultItemEvent(new FocusResultItemEventArgs(focusItem));
            }
        }

        #endregion Public Events

        #region Logging

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void Write(string msg)
        {
            if (string.IsNullOrEmpty(LogFileName) == false)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(LogFileName, true, System.Text.Encoding.UTF8);
                writer.Write(msg);
                writer.Close();
            }

#if DEBUG
            System.Diagnostics.Debug.Write(msg);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLine(string msg)
        {
            if (string.IsNullOrEmpty(LogFileName) == false)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(LogFileName, true, System.Text.Encoding.UTF8);
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm ") + msg);
                writer.Close();
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine(msg);
#endif
        }

        #endregion Loggin
    }
}
