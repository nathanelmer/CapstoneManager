import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { useParams } from "react-router-dom";
import { Card, Container } from "reactstrap";
import { deleteStudent, getStudentById } from "../modules/studentManager";

export const StudentDelete = () => {
    const [student, setStudent] = useState({});
    const { id } = useParams();
    const history = useHistory();

    useEffect(() => {
        getStudentById(id)
            .then(data => setStudent(data))
    }, [])

    const handleDelete = (id) => {
        deleteStudent(id)
            .then(() => history.push(`/class/${student.classId}`))
    }

    return (
        <Container>
            <Card>
                <h2>Are you sure you want to delete {student.name}?</h2>
                <button onClick={() => handleDelete(student.id)}>Delete</button>
                <button onClick={() => history.push(`/class/${student.classId}`)}>Go Back</button>
            </Card>
        </Container >
    )
}