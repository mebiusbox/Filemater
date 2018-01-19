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
using System.Windows.Forms;
using System.Xml;

namespace Filemater.Nodes.Filter
{
    public class TimeNode : IFilterNode
    {
        public enum TimeKind
        {
            CTIME = 0,
            UTIME,
            ATIME
        }

        public static string[] TimeKindText = {
            "作成時間",
            "最終更新時間",
            "最終アクセス時間"
        };

        public static string[] TimeKindTextEn = {
            "create-time",
            "update-time",
            "access-time"
        };

        public enum TimeMethodType
        {
            BEFORE = 0,
            AFTER,
            SAME,
            IN_RANGE,
            OUT_RANGE
        }

        public static string[] TimeMethodTypeText = {
            "より前",
            "より後",
            "一致",
            "範囲内",
            "範囲外"
        };

        public static string[] TimeMethodTypeTextEn = {
            "before",
            "after",
            "same",
            "in-range",
            "out-range"
        };

        #region Properties

        public TimeKind Kind = TimeKind.CTIME;
        public DateTime Time1;
        public DateTime Time2;
        public TimeMethodType MethodType = TimeMethodType.BEFORE;

        #endregion

        #region Ctor/Dtor

        public TimeNode()
        {
            this.Text = "Time";
            this.Time1 = DateTime.Now;
            this.Time2 = DateTime.Now;
        }

        #endregion

        private ITimeMethod m_method;

        #region TimeMethod classes

        public abstract class ITimeMethod
        {
            public abstract bool Eval(DateTime value, DateTime time1, DateTime time2);
        }

        public class TimeMethodBefore : ITimeMethod
        {
            public override bool Eval(DateTime value, DateTime time1, DateTime time2)
            {
                return (value < time1);
            }
        }

        public class TimeMethodAfter : ITimeMethod
        {
            public override bool Eval(DateTime value, DateTime time1, DateTime time2)
            {
                return (value > time1);
            }
        }

        public class TimeMethodSame : ITimeMethod
        {
            public override bool Eval(DateTime value, DateTime time1, DateTime time2)
            {
                return (value == time1);
            }
        }

        public class TimeMethodInRange : ITimeMethod
        {
            public override bool Eval(DateTime value, DateTime time1, DateTime time2)
            {
                return (time1 <= value && value <= time2);
            }
        }

        public class TimeMethodOutRange : ITimeMethod
        {
            public override bool Eval(DateTime value, DateTime time1, DateTime time2)
            {
                return (value < time1 || time2 < value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ITimeMethod CreateMethod(TimeMethodType type)
        {
            switch (type)
            {
                case TimeMethodType.BEFORE:
                    return new TimeMethodBefore();

                case TimeMethodType.AFTER:
                    return new TimeMethodAfter();

                case TimeMethodType.SAME:
                    return new TimeMethodSame();

                case TimeMethodType.IN_RANGE:
                    return new TimeMethodInRange();

                case TimeMethodType.OUT_RANGE:
                    return new TimeMethodOutRange();
            }

            return null;
        }

        #endregion

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new TimeNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            this.m_method = CreateMethod(this.MethodType);

            DateTime time = GetTime(this.Input);
            DateTime val = new DateTime(time.Year, time.Month, time.Day);
            if (this.m_method != null && this.m_method.Eval(val, Time1, Time2))
            {
                Dispatch(0, this.Input);
            }
            else
            {
                Dispatch(1, this.Input);
            }
        }

        #endregion

        #region Serialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public override void Serialize(System.Xml.XmlWriter w)
        {
            base.Serialize(w);

            w.WriteElementString("Target", TimeKindTextEn[(int)this.Kind]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Time1", this.Time1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Time2", this.Time2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Method", TimeMethodTypeTextEn[(int)this.MethodType]);
            w.WriteWhitespace("\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void Deserialize(System.Xml.XmlReader r)
        {
            base.Deserialize(r);
            this.Kind = (TimeKind)libpixy.net.Utils.ArrayUtils.IndexOf(TimeKindTextEn, r.ReadElementString("Target"));
            this.Time1 = DateTime.Parse(r.ReadElementString("Time1"));
            this.Time2 = DateTime.Parse(r.ReadElementString("Time2"));
            this.MethodType = (TimeMethodType)libpixy.net.Utils.ArrayUtils.IndexOf(TimeMethodTypeTextEn, r.ReadElementString("Method"));
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private DateTime GetTime(File file)
        {
            DateTime time = DateTime.Now;
            switch (this.Kind)
            {
                case TimeKind.CTIME:
                    time = file.CTime;
                    break;

                case TimeKind.UTIME:
                    time = file.UTime;
                    break;

                case TimeKind.ATIME:
                    time = file.ATime;
                    break;
            }

            return new DateTime(time.Year, time.Month, time.Day);
        }
    }
}
