﻿#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

using NUnit.Framework;

using SharpRaven.Data;
using SharpRaven.UnitTests.Utilities;

namespace SharpRaven.UnitTests.Data
{
    [TestFixture]
    public class SentryStackTracetests
    {
        [Test]
        public void Constructor_ExceptionWithFrames_FramesAreAsExpected()
        {
            var exception = TestHelper.GetException();
            SentryStacktrace stacktrace = new SentryStacktrace(exception);

            Console.WriteLine(exception);

            Assert.That(stacktrace.Frames, Is.Not.Null);
            Assert.That(stacktrace.Frames, Has.Length.EqualTo(2));
        }


        [Test]
        public void Constructor_NullException_DoesNotThrow()
        {
            SentryStacktrace stacktrace = new SentryStacktrace(null);

            Assert.That(stacktrace.Frames, Is.Null);
        }


        [Test]
        public void ToString_StringIsEqualTo_ExceptionToString()
        {
            var exception = TestHelper.GetException();
            SentryStacktrace stacktrace = new SentryStacktrace(exception);
            string exceptionString = exception.ToString();
            string stacktraceString = stacktrace.ToString();

            Console.WriteLine(exceptionString);
            Console.WriteLine();
            Console.WriteLine(stacktraceString);

            Assert.That(stacktraceString, Is.EqualTo(exceptionString));
        }
    }
}