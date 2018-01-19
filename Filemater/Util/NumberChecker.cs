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

namespace Filemater.Util
{
    public class NumberChecker
    {
        /// <summary>
        /// 
        /// </summary>
        public enum MethodType
        {
            LESS = 0,
            MORE,
            SAME,
            IN_RANGE,
            OUT_RANGE
        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] MethodTypeText = {
            "ÇÊÇËè¨Ç≥Ç¢",
            "ÇÊÇËëÂÇ´Ç¢",
            "ìØÇ∂",
            "îÕàÕì‡",
            "îÕàÕäO"
        };

        /// <summary>
        /// 
        /// </summary>
        public static string[] MethodTypeTextEn = {
            "less",
            "more",
            "same",
            "in-range",
            "out-range"
        };

        #region long value

        public abstract class ILongValueMethod
        {
            public abstract bool Eval(long value, long size1, long size2);
        }

        public class LongValueMethodLess : ILongValueMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value < size1);
            }
        }

        public class LongValueMethodMore : ILongValueMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value > size1);
            }
        }

        public class LongValueMethodSame : ILongValueMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value == size1);
            }
        }

        public class LongValueMethodInRange : ILongValueMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (size1 <= value && value <= size2);
            }
        }

        public class LongValueMethodOutRange : ILongValueMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value < size1 || size2 < value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ILongValueMethod CreateLongValueMethod(MethodType type)
        {
            switch (type)
            {
                case MethodType.LESS:
                    return new LongValueMethodLess();

                case MethodType.MORE:
                    return new LongValueMethodMore();

                case MethodType.SAME:
                    return new LongValueMethodSame();

                case MethodType.IN_RANGE:
                    return new LongValueMethodInRange();

                case MethodType.OUT_RANGE:
                    return new LongValueMethodOutRange();
            }

            return null;
        }

        #endregion

        #region float value

        public abstract class IFloatValueMethod
        {
            public abstract bool Eval(float value, float size1, float size2);
        }

        public class FloatValueMethodLess : IFloatValueMethod
        {
            public override bool Eval(float value, float size1, float size2)
            {
                return (value < size1);
            }
        }

        public class FloatValueMethodMore : IFloatValueMethod
        {
            public override bool Eval(float value, float size1, float size2)
            {
                return (value > size1);
            }
        }

        public class FloatValueMethodSame : IFloatValueMethod
        {
            public override bool Eval(float value, float size1, float size2)
            {
                return (value == size1);
            }
        }

        public class FloatValueMethodInRange : IFloatValueMethod
        {
            public override bool Eval(float value, float size1, float size2)
            {
                return (size1 <= value && value <= size2);
            }
        }

        public class FloatValueMethodOutRange : IFloatValueMethod
        {
            public override bool Eval(float value, float size1, float size2)
            {
                return (value < size1 || size2 < value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IFloatValueMethod CreateFloatValueMethod(MethodType type)
        {
            switch (type)
            {
                case MethodType.LESS:
                    return new FloatValueMethodLess();

                case MethodType.MORE:
                    return new FloatValueMethodMore();

                case MethodType.SAME:
                    return new FloatValueMethodSame();

                case MethodType.IN_RANGE:
                    return new FloatValueMethodInRange();

                case MethodType.OUT_RANGE:
                    return new FloatValueMethodOutRange();
            }

            return null;
        }

        #endregion
    }
}
