using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CapstoneManager.Models;
using CapstoneManager.Utils;

namespace CapstoneManager.Repositories
{
    public class ClassRepository : BaseRepository, IClassRepository
    {
        public ClassRepository(IConfiguration configuration) : base(configuration) { }

        public List<Class> GetClassesByTeacherId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Name, c.Id
                                        FROM Class c
                                        JOIN TeacherClass tc ON tc.ClassId = c.Id
                                        WHERE tc.TeacherId = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    List<Class> classes = new List<Class>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Class cls = new Class()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name")
                        };
                        classes.Add(cls);
                    }
                    reader.Close();
                    return classes;
                }
            }
        }

    }
}
