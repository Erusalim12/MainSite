namespace Application.Services.Files
{
    public class AppMediaDefaults
    {
        /// <summary>
        /// Gets a multiple thumb directories length
        /// </summary>
        public static int MultipleThumbDirectoriesLength => 3;

        /// <summary>
        /// Gets a path to the image thumbs files
        /// </summary>
        public static string ImageThumbsPath => @"images\thumbs";

        /// <summary>
        /// Gets a default avatar file name
        /// </summary>
        public static string DefaultAvatarFileName => @"images\layout_icons\user.png";

        /// <summary>
        /// Gets a default image file name
        /// </summary>
        public static string DefaultImageFileName => @"\images\layout_icons\education.jpg";

        /// <summary>
        /// Gets a path to the files
        /// </summary>
        public static string DefaultPathToFileCatalog => @"files\";

        public static string PathToNewsMedia => @"files\news";
    }
}