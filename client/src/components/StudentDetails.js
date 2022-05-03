
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Card, CardBody, CardLink, CardSubtitle, CardTitle, Container } from "reactstrap";
import { getStudentById } from "../modules/studentManager";

export const StudentDetails = () => {
    const [student, setStudent] = useState({});
    const { id } = useParams();

    useEffect(() => {
        getStudentById(id)
            .then(data => setStudent(data))
    }, [])
    return (
        <Container>
            <Card>
                <CardTitle>{student.name}</CardTitle>
                <CardSubtitle>{student.proposalTitle}</CardSubtitle>
                <CardBody>Status: {student.progress?.name}</CardBody>
                <CardBody>Notes: {student.note}</CardBody>
                <CardLink href={`/class/${student.classId}`}>Go Back</CardLink>
            </Card>
        </Container >
    )
}