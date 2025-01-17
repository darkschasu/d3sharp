﻿﻿/*
 * Copyright (C) 2011 D3Sharp Project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Collections.Generic;
using System.Linq;
using D3Sharp.Utils.Extensions;

namespace D3Sharp.Net.Game.Packets
{
    public class GamePacket
    {
        public GameHeader Header { get; protected set; }
        public IEnumerable<byte> Payload { get; set; }


        public GamePacket(GameHeader header, byte[] payload)
        {
            this.Header = header;
            this.Payload = payload;
        }

        public UInt32 Length
        {
            get { return this.Header.Length; }
        }

        public byte[] GetRawPacketData()
        {
            return this.Header.Data.Append(this.Payload.ToArray());
        }

        public override string ToString()
        {
            return string.Format(
                "Header\t: {0}\nData\t: {1}- {2}",
                this.Header,
                this.Header.Data.HexDump(),
                this.Payload.HexDump()
                );
        }

    }
}