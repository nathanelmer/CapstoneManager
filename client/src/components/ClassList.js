import { useState, useEffect } from "react";
import { Container } from "reactstrap";
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
        </Container>
    );
}