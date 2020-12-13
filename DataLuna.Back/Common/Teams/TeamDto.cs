namespace DataLuna.Back.Common.Teams
{
    public class TeamDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public TeamPlayerDto[] Players { get; set; }
    }

    public class TeamPlayerDto
    {
        public string NickName { get; set; }
    }
}