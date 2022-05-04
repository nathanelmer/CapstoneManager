using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CapstoneManager.Models;
using CapstoneManager.Utils;

namespace CapstoneManager.Repositories
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public TeacherRepository(IConfiguration configuration) : base(configuration) { }
        public Teacher GetByFirebaseUserId(string id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, FirebaseUserId, Name, Email
                                        FROM Teacher
                                        WHERE FirebaseUserId = @firebaseId";
                    cmd.Parameters.AddWithValue("@firebaseId", id);
                    var reader = cmd.ExecuteReader();
                    Teacher teacher = null;
                    if (reader.Read())
                    {
                        teacher = new Teacher()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email")
                        };
                    }
                    reader.Close();
                    return teacher;
                }
            }
        }
        public void Add(Teacher teacher)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Teacher (FirebaseUserId, Name, Email)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @Name, @Email)";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", teacher.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@Name", teacher.Name);
                    DbUtils.AddParameter(cmd, "@Email", teacher.Email);

                    teacher.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
