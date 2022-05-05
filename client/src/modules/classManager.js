import { getToken } from "./authManager"

const classUrl = "/api/class";

export const getClasses = () => {
    return getToken().then((token) => {
        return fetch(`${classUrl}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("Unknown error getting classes");
            }
        });
    });
};

export const getAllClasses = () => {
    return getToken().then((token) => {
        return fetch(`${classUrl}/all`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error("Unknown error getting classes");
            }
        });
    });
};

export const addClass = (newClass) => {
    return getToken().then((token) => {
        return fetch(`${classUrl}`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newClass)
        })
    })
}

export const deleteClass = (id) => {
    return getToken().then((token) => {
        return fetch(`${classUrl}/${id}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
        });
    });
};

export const addTeacherClass = (teacherClass) => {
    return getToken().then((token) => {
        return fetch(`${classUrl}/teacherClass`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(teacherClass)
        })
    })
}

export const joinClass = (teacherClass) => {
    return getToken().then((token) => {
        return fetch(`${classUrl}/join`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(teacherClass)
        })
    })
}