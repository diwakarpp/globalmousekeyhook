﻿using System.Collections.Generic;

namespace MouseKeyboardActivityMonitor.HotKeys
{

    /// <summary>
    /// A collection of HotKeySets
    /// </summary>
    public sealed class HotKeySetCollection : List< HotKeySet >
    {

        private delegate void KeyChainHandler( KeyEventArgsExt kex );

        private KeyChainHandler _keyChain;

        ///<summary>
        /// Adds a HotKeySet to the collection.
        ///</summary>
        ///<param name="hks"></param>
        public new void Add( HotKeySet hks )
        {
            _keyChain += hks.OnKey;
            base.Add( hks );
        }

        ///<summary>
        /// Removes the HotKeySet from the collection.
        ///</summary>
        ///<param name="hks"></param>
        public new void Remove( HotKeySet hks )
        {
            _keyChain -= hks.OnKey;
            base.Remove( hks );
        }

        /// <summary>
        /// Uses a multicase delegate to invoke individual HotKeySets if the Key is in use by any HotKeySets.
        /// </summary>
        /// <param name="e"></param>
        internal void OnKey( KeyEventArgsExt e )
        {
            if ( _keyChain != null )
                _keyChain( e );
        }

    }

}
