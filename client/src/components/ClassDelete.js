import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useHistory } from "react-router-dom";
import { Card, CardBody, CardLink, CardSubtitle } from "reactstrap";
import { deleteClass, getClasses } from "../modules/classManager";

export const ClassDelete = () => {
    const [currentClass, setCurrentClass] = useState({})
    const history = useHistory();
    const { id } = useParams();

    const handleDelete = (id) => {
        deleteClass(id).then(() => history.push(`/`));
    }

    useEffect(() => {
        getClasses()
            .then((classes) => classes.find(c => c.id === parseInt(id)))
            .then((clas) => setCurrentClass(clas))
    }, [])

    return (
        <Card>
            <CardBody>
                <CardSubtitle>Are you sure you want to delete {currentClass.name}?</CardSubtitle>
                <button onClick={() => handleDelete(currentClass.id)}>Delete</button>
                <CardLink href={`/`}>Go Back</CardLink>
            </CardBody>
        </Card>
    );
};

