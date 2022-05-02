import { getToken } from "./authManager";

const studentUrl = "/api/student";

export const getStudentsByClassId = (id) => {
    return getToken().then((token) => {
        return fetch(`${studentUrl}/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("Unknown error getting students");
            }
        });
    });
}