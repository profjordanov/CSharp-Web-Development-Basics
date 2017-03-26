using System;

namespace SoftStore.BindingModels
{
    public class GameBm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ReleaseDate { get; set; }
    }
}
