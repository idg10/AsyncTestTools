﻿using System.Threading.Tasks;
using Xunit;

namespace Idg.AsyncTest.Tests.CompletionSourceTests.WithResult
{
    public class WhenGetTaskCalledOnceAfterDoubleWait : CompletionSourceWithResultTestBase
    {
        private Task _wait;

        public WhenGetTaskCalledOnceAfterDoubleWait()
        {
            _wait = Source.WaitAsync(2);
            Source.GetTask();
        }

        [Fact]
        public void WaitDoesNotComplete()
        {
            Assert.False(_wait.IsCompleted);
        }

        [Fact]
        public void CallCountIsOne()
        {
            Assert.Equal(1, Source.CallCount);
        }
    }
}
