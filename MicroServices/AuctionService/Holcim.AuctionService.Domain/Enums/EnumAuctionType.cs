using System;
using System.Collections.Generic;

namespace Holcim.AuctionService.Domain.Enums
{
    public enum AuctionType
    {
        Inglesa,
        Japonesa,
        Holandesa
    }

    public static class AuctionTypeExtensions
    {
        private static readonly Dictionary<AuctionType, Guid> AuctionTypeGuids = new()
        {
            { AuctionType.Inglesa, Guid.Parse("4e92f7ba-0373-4c5d-91fa-6de32d6a5e15") },
            { AuctionType.Japonesa, Guid.Parse("b184c5ea-3a43-45d0-b348-9f11c7f9d68a") },
            { AuctionType.Holandesa, Guid.Parse("ad08c0a9-5e90-4c0f-8b45-17f54bc9e8c6") }
        };

        // Método para obtener el GUID de un AuctionType
        public static Guid GetGuid(this AuctionType auctionType)
        {
            return AuctionTypeGuids[auctionType];
        }
    }
}
