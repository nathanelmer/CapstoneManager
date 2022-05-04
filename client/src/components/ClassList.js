import { useState, useEffect } from "react";
import { CardLink, Container } from "reactstrap";
import { getClasses } from "../modules/classManager";
import { Class } from "./Class";

export default function ClassList() {
    const [classes, setClasses] = useState([])

    useEffect(() => {
        getClasses().then(data => setClasses(data))
    }, [])

    return (
        <Container>
            {
                classes.map((c) => (
                    <Class clas={c} key={c.id} />
                ))
            }
            <CardLink href={`/class/add`}>Add New Class</CardLink>
        </Container>
    );
}