using Microsoft.Extensions.Configuration;
using CapstoneManager.Models;
using CapstoneManager.Utils;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public class ProgressRepository : BaseRepository, IProgressRepository
    {
        public ProgressRepository(IConfiguration config) : base(config) { }

        public List<Progress> GetProgressTypes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, ImageUrl
                                        FROM Progress";
                    var reader = cmd.ExecuteReader();
                    List<Progress> progressList = new List<Progress>();
                    while (reader.Read())
                    {
                        progressList.Add(new Progress()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl")
                        });
                    }
                    reader.Close();
                    return progressList;
                }
            }
        }
    }
}
