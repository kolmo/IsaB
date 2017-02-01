using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Template10.Mvvm;

namespace IsaB.ViewModels
{
    public class EditViewModelBase : ViewModelBase
    {
        #region Public Properties
        private bool _hasChanges;
        /// <summary>
        /// 
        /// </summary>
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                base.Set(ref _hasChanges, value);
                CommandBag.ForEach(x => x.RaiseCanExecuteChanged());
            }
        }
        #endregion

        #region Protected members
        protected List<DelegateCommand> CommandBag { get; } = new List<DelegateCommand>();
        #endregion

        #region Overrides
        public override bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            bool setResult = base.Set<T>(ref storage, value, propertyName);
            if (setResult)
                HasChanges = true;
            return setResult;
        }
        #endregion
    }
}
