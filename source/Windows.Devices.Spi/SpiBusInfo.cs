﻿//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents the info about a SPI bus.
    /// </summary>
    public sealed class SpiBusInfo
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int _controllerId;

        internal SpiBusInfo(string spiBus)
        {
            _controllerId = spiBus[3] - '0';

        }

        /// <summary>
        /// Gets the number of chip select lines available on the bus.
        /// </summary>
        /// <value>
        /// Number of chip select lines.
        /// </value>
        public int ChipSelectLineCount
        {
            get { return NativeChipSelectLineCount(_controllerId); }
        }

        /// <summary>
        /// Maximum clock cycle frequency of the bus.
        /// </summary>
        /// <value>
        /// The clock cycle in Hz.
        /// </value>
        public int MaxClockFrequency
        {
            get { return NativeMaxClockFrequency(_controllerId); }
        }

        /// <summary>
        /// Minimum clock cycle frequency of the bus.
        /// </summary>
        /// <value>
        /// The clock cycle in Hz.
        /// </value>
        public int MinClockFrequency
        {
            get { return NativeMinClockFrequency(_controllerId); }
        }

        /// <summary>
        /// Gets the bit lengths that can be used on the bus for transmitting data.
        /// </summary>
        /// <value>
        /// The supported data lengths.
        /// </value>
        public int[] SupportedDataBitLengths
        {
            get
            {
                return new[] {8, 16};
            }
        }

        #region Native Calls


        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int NativeChipSelectLineCount(int controllerId);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int NativeMaxClockFrequency(int controllerId);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int NativeMinClockFrequency(int controllerId);


        #endregion




    }
}
