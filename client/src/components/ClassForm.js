import { useState } from "react";
import { useHistory } from "react-router-dom";
import { Form, FormGroup, Input, Label } from "reactstrap";
import { addClass } from "../modules/classManager";

export const ClassForm = () => {
    const emptyClass = {
        name: ""
    }
    const [newClass, setNewClass] = useState(emptyClass)
    const history = useHistory();

    const postClass = (e) => {
        e.preventDefault();
        addClass(newClass)
            .then(() => history.push(`/`));

    };

    const handleInputChange = (evt) => {
        const value = evt.target.value;
        const key = evt.target.id;

        const classCopy = { ...newClass };

        classCopy[key] = value;
        setNewClass(classCopy);
    };
    return (
        <Form>
            <FormGroup>
                <Label for="name">Class Name</Label>
                <Input
                    required
                    id="name"
                    name="name"
                    type="text"
                    value={newClass.name || ""}
                    onInput={handleInputChange}
                />
            </FormGroup>
            <button disabled={!newClass.name} onClick={(e) => postClass(e)}>
                Save
            </button>
            <button className="ml-2" onClick={() => history.push(`/`)}>
                Go Back
            </button>
        </Form>
    )
}