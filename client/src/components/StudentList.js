import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getStudentsByClassId } from "../modules/studentManager";
import { Card, CardBody, CardLink, CardSubtitle, Container } from "reactstrap";
import "../index.css";
import { getProgressTypes } from "../modules/progressManager";

export const StudentList = () => {
    const [students, setStudents] = useState([])
    const [progressTypes, setProgressTypes] = useState([])
    const { id } = useParams()

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
                    {progressTypes.map(p => <option value={p.id}>{p.name}</option>)}
                </select>
            </div>
            {students.map(s => <Card key={s.id}>
                <CardBody>{s.name}</CardBody>
                <CardLink>Edit</CardLink>
                <CardSubtitle>
                    <img src={s.progress.imageUrl} />
                </CardSubtitle>
            </Card>)}
        </Container>
    )
}