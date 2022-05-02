import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getStudentsByClassId } from "../modules/studentManager";

export const CompletedStudentList = () => {
    const [students, setStudents] = useState([])
    const { id } = useParams()

    useEffect(() => {
        getStudentsByClassId(id)
            .then((data) => data.filter(d => d.progress.id === 1))
            .then((completed) => setStudents(completed))
    }, [])

    return (
        <div></div>
    )
}