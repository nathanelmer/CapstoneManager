import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getStudentsByClassId } from "../modules/studentManager";
import { Card, CardBody, CardImg, CardLink, CardSubtitle, Container } from "reactstrap";
import { StudentFilterNav } from "./StudentFilterHeader";
import "../index.css";

export const StudentList = () => {
    const [students, setStudents] = useState([])
    const { id } = useParams()
    useEffect(() => {
        getStudentsByClassId(id).then((data) => setStudents(data))
    }, [])

    return (
        <Container>
            <StudentFilterNav />
            {students.map(s => <Card>
                <CardBody>{s.name}</CardBody>
                <CardLink>Edit</CardLink>
                <CardSubtitle>
                    <img src={s.progress.imageUrl} />
                </CardSubtitle>
            </Card>)}
        </Container>
    )
}