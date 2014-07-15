using VkApiLibrary.Categories;

namespace VkApiLibrary.Objects
{
    public class VkontakteApi
    {
        internal static string _token;
        int _userId;

        public UserCategory Users { private set; get; }
        public DatabaseCategory Database { private set; get; }
        public WallCategory Wall { private set; get; }

        public User CurrentUser;


        public VkontakteApi(int userId, string token)
        {
            _userId = userId;
            _token = token;

            Users = new UserCategory();
            Database = new DatabaseCategory();
            Wall = new WallCategory();

            CurrentUser = Users.Get(userId, ProfileFields.all);
        }
    }
}
