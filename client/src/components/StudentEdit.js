import { Button } from "bootstrap";
import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { useParams } from "react-router-dom";
import { Container, Form, FormGroup, Input, Label } from "reactstrap";
import { getProgressTypes } from "../modules/progressManager";
import { editStudent, getStudentById } from "../modules/studentManager";

export const StudentEdit = () => {
    const emptyStudent = {
        id: "",
        proposalTitle: "",
        name: "",
        progressId: "",
        note: ""
    }
    const [student, setStudent] = useState(emptyStudent);
    const [progressTypes, setProgressTypes] = useState([]);
    const { id } = useParams();
    const history = useHistory();

    useEffect(() => {
        getStudentById(id)
            .then(data => setStudent(data));

        getProgressTypes()
            .then(data => setProgressTypes(data));
    }, [])

    const updateStudent = () => {
        editStudent(student).then(() => history.go(`/class/1`));
    };

    const handleInputChange = (evt) => {
        student.id = id;
        const value = evt.target.value;
        const key = evt.target.id;

        const studentCopy = { ...student };

        studentCopy[key] = value;
        setStudent(studentCopy);
    };

    return (
        <Container>
            <Form>
                <FormGroup>
                    <Label for="name">Student Name</Label>
                    <Input
                        required
                        id="name"
                        name="name"
                        type="text"
                        value={student.name || ""}
                        onInput={handleInputChange}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="proposalTitle">Proposal Title</Label>
                    <Input
                        required
                        id="proposalTitle"
                        name="proposalTitle"
                        type="text"
                        value={student.proposalTitle || ""}
                        onInput={handleInputChange}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="note">Notes</Label>
                    <Input
                        id="note"
                        name="note"
                        type="text"
                        value={student.note || ""}
                        onInput={handleInputChange}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="progressId">Progress Status -- Currently: {student.progress?.name}</Label>
                    <Input
                        id="progressId"
                        required
                        name="progressId"
                        type="select"
                        value={student.progressId || 0}
                        onChange={handleInputChange}
                    >
                        <option value="0">Select Progress</option>
                        {progressTypes?.map((p) => (
                            <option key={`p--${p.id}`} value={p.id}>
                                {p.name}
                            </option>
                        ))}
                    </Input>
                </FormGroup>
                <button disabled={!student.proposalTitle || !student.progressId || !student.name} onClick={() => updateStudent()}>
                    Save
                </button>
                <button className="ml-2" onClick={() => history.push(`/class/${student.classId}`)}>
                    Go Back
                </button>
            </Form>
        </Container>
    )
}