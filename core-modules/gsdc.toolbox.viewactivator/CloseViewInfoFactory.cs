using System;

namespace gsdc.toolbox.viewactivator
{
    internal sealed class CloseViewInfoFactory : ICloseViewInfoFactory
    {
        private readonly Func<Type, ICloseViewInfo> _factory;
        public CloseViewInfoFactory(Func<Type, ICloseViewInfo> factory) => _factory = factory;

        public ICloseViewInfo CreateInfo<TViewInterface>()
            => _factory(typeof(TViewInterface));
    }
}