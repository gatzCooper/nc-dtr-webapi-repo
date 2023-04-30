using System;
using System.Collections.Generic;

#nullable disable

namespace api.dataaccess.entityframework.model
{
    public partial class TblAdvertisement
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
