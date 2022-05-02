import React from "react";
import { Link } from "react-router-dom";
import { Card, CardBody, CardLink, CardSubtitle } from "reactstrap";

export const Class = ({ clas }) => {
    return (
        <Card>
            <CardBody>
                <CardSubtitle>{clas.name}</CardSubtitle>
                <CardLink href={`/class/${clas.id}`}>Manage</CardLink>
            </CardBody>
        </Card>
    );
};

export default Class;