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
