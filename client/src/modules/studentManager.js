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

export const getStudentById = (id) => {
    return getToken().then((token) => {
        return fetch(`${studentUrl}/details/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("Unknown error getting student");
            }
        });
    });
}

export const editStudent = (student) => {
    return getToken().then((token) => {
        return fetch(`${studentUrl}/edit/${student.id}`, {
            method: "PUT",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(student),
        });
    });
};