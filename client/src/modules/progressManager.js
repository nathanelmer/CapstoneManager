
const progressUrl = "/api/progress";

export const getProgressTypes = () => {
    return fetch(`${progressUrl}`)
        .then(data => data.json())
}