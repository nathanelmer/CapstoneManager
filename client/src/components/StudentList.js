import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getStudentsByClassId, deleteStudent } from "../modules/studentManager";
import { Card, CardTitle, CardSubtitle, Container, CardLink } from "reactstrap";
import "../index.css";
import { getProgressTypes } from "../modules/progressManager";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom";

export const StudentList = () => {
    const [students, setStudents] = useState([]);
    const [progressTypes, setProgressTypes] = useState([]);
    const { id } = useParams();
    const history = useHistory();

    useEffect(() => {
        getStudentsByClassId(id)
            .then((data) => setStudents(data));

        getProgressTypes()
            .then(data => setProgressTypes(data));
    }, [])

    const filterList = (value) => {
        console.log(value)
        if (value === "0") {
            getStudentsByClassId(id).then(data => setStudents(data))
        } else {
            getStudentsByClassId(id).then(data => data.filter(d => d.progress.id === parseInt(value)))
                .then(filtered => setStudents(filtered))
        }
    }
    return (
        <Container>
            <div>
                <select onChange={(e) => filterList(e.target.value)}>
                    <option value="0">All Students</option>
                    {progressTypes.map(p => <option key={p.id} value={p.id}>{p.name}</option>)}
                </select>
                <button onClick={() => history.push(`/class/student/add/${id}`)}>Add Student</button>
            </div>
            {students.map(s => <Card key={s.id}>
                <CardTitle>
                    <Link to={`student/details/${s.id}`}>{s.name}</Link>
                </CardTitle>
                <CardSubtitle>
                    <img src={s.progress.imageUrl} />
                </CardSubtitle>
                <CardLink href={`/class/student/edit/${s.id}`}>Manage</CardLink>
                <CardLink href={`/class/student/delete/${s.id}`}>Delete</CardLink>
            </Card>)}
        </Container>
    )
}