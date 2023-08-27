using System;

namespace PlainBytes.System.Extensions.Collections
{
    /// <summary>
    /// Allows disposing multiple <see cref="IDisposable"/>s at the same time.
    /// </summary>
    public class CompositeDisposable : IDisposable
    {
        private readonly IDisposable[] _disposables;

        /// <summary>
        /// Creates an instance from the provided disposables.
        /// </summary>
        public CompositeDisposable(params IDisposable[] disposables)
        {
            _disposables = disposables ?? throw new ArgumentNullException(nameof(disposables));
        }
        
        /// <summary>
        /// <inheritdoc cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}