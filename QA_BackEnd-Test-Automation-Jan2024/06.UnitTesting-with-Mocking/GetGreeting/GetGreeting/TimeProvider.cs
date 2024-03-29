﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGreeting
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    // Manual mocking
    public class FakeTimeProvider : ITimeProvider
    {
        private DateTime _fakeTime;

        public FakeTimeProvider(DateTime fakeTime)
        {
            _fakeTime = fakeTime;
        }

        public DateTime GetCurrentTime()
        {
            return _fakeTime;
        }
    }
}
