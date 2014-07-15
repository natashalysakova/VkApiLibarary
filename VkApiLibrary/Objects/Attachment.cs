using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkApiLibrary.Objects
{
    public class Attachment
    {
        private readonly int _ownerId;
        private readonly int _mediaId;
        private readonly AttachmentType _type;

        public Attachment(int ownerId, int mediaId, AttachmentType type)
        {
            _ownerId = ownerId;
            _mediaId = mediaId;
            _type = type;
        }

        public override string ToString()
        {
            return _type.ToString() + _ownerId + "_" + _mediaId;
        }
    }
}
