namespace Demo.presentation.ViewModels.RolesViewModel
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string RoleName { get; set; }
    }
}
