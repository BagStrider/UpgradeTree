using System;

namespace Abstractions.Lockable
{
    public interface ILockable
    {
        public event Action<LockState> OnLockChanged;
        public void Unlock();
        public void Lock();
    }
}