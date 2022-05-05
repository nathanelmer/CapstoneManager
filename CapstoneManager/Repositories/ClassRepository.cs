using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CapstoneManager.Models;
using CapstoneManager.Utils;
using System.Linq;

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

        public List<Class> GetAllClasses()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Name, c.Id, tc.ClassId, tc.TeacherId, tc.Id tcId
                                        FROM Class c
                                        JOIN TeacherClass tc ON tc.ClassId = c.Id";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var classes = new List<Class>();
                        while (reader.Read())
                        {
                            var classId = DbUtils.GetInt(reader, "Id");
                            var existingClass = classes.FirstOrDefault(c => c.Id == classId);
                            if (existingClass == null)
                            {
                                existingClass = new Class()
                                {
                                    Id = classId,
                                    Name = DbUtils.GetString(reader, "Name"),
                                    TeacherClasses = new List<TeacherClass>()
                                };

                                classes.Add(existingClass);
                            }


                            if (DbUtils.IsNotDbNull(reader, "tcId"))
                            {
                                existingClass.TeacherClasses.Add(new TeacherClass()
                                {
                                    Id = DbUtils.GetInt(reader, "tcId"),
                                    ClassId = DbUtils.GetInt(reader, "ClassId"),
                                    TeacherId = DbUtils.GetInt(reader, "TeacherId")
                                });
                            }
                        }
                        return classes;
                    }
                }
            }
        }
        public int Add(Class newClass)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Class (Name)
                                        OUTPUT INSERTED.ID
                                        VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", newClass.Name);
                    newClass.Id = (int)cmd.ExecuteScalar();
                    return newClass.Id;
                }
            }
        }

        public void AddTeacherClass(TeacherClass tc)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO TeacherClass (ClassId, TeacherId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@classId, @teacherId)";
                    cmd.Parameters.AddWithValue("@classId", tc.ClassId);
                    cmd.Parameters.AddWithValue("@teacherId", tc.TeacherId);
                    tc.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Class
                                        WHERE Id = @id";
                        
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
