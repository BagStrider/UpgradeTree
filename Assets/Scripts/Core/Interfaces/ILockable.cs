using System;
using Core.Base;

namespace Core.Interfaces
{
    public interface ILockable
    {
        public event Action<LockState> OnLockChanged;
        public void Unlock();
        public void Lock();
    }
}