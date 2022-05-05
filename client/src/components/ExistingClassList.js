import { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Card, CardBody, CardLink, CardSubtitle, Container } from "reactstrap";
import { getAllClasses, joinClass } from "../modules/classManager";

export default function ExistingClassList() {
    const [classes, setClasses] = useState([])
    const history = useHistory();

    useEffect(() => {
        getAllClasses().then(data => setClasses(data))
    }, [])

    const handleJoin = (c) => {
        const tcObject = { classId: c }
        joinClass(tcObject).then(() => history.push(`/`));
    }

    return (
        <Container>
            {
                classes.map((c) => (
                    <Card key={c.id}>
                        <CardBody>
                            <CardSubtitle>{c.name}</CardSubtitle>
                            <CardLink onClick={() => handleJoin(c.id)}>Join</CardLink>
                        </CardBody>
                    </Card>
                ))
            }
            <CardLink href={`/`}>Go Back</CardLink>
        </Container>
    );
}