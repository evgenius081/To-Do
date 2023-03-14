import React, {useCallback, useContext, useEffect, useState} from 'react';
import {useNavigate, useParams} from "react-router-dom";
import { TokenContext } from "../../App";
import {Error} from "../Error";
import {readList, updateList} from "./listOperations";

export function EditList() {
    const [title, setTitle] = useState("");
    const [archived, setArchived] = useState(false);
    const [errors, setErrors] = useState([])
    const navigate = useNavigate();
    const { id } = useParams();
    const { token } = useContext(TokenContext);

    const getData = useCallback(async () => {
        await readList(id, token)
            .then(async (response) => {
                if (response.ok){
                    let data = await response.json()
                    setTitle(data.title)
                    setArchived(data.isArchived)
                }
                else if (response.status === 401){
                    navigate("login")
                }
                else if (response.status === 404){
                    navigate("/notFound")
                }
                else if (response.status === 500){
                    navigate("/error")
                }

            })
    }, [id, token, setArchived, navigate, setTitle])

    useEffect(() => {
        getData().then()
    }, [getData])

    async function submitHandler(e){
        e.preventDefault()
        let data = {
            id: parseInt(id),
            title: title,
            isArchived: archived
        }
        await updateList(data, token).then(async (response) => {
            if (response.ok){
                navigate(-1)
            } else if (response.status === 401){
                navigate("/login")
            }else if (response.status === 400){
                let data = await response.json()
                setErrors(await data.errors.Title)
            }
            else if (response.status === 500){
                navigate("/error")
            }
        })
    }

    return (
        <form>
            <div className="form-group">
                <label htmlFor="list-title-input">Title</label>
                <input type="text" className="form-control" id="list-title-input" aria-describedby="list-title-help"
                       placeholder="Enter title" value={title} onChange={(e) => setTitle(e.target.value)} />
            </div>
            <div className="form-group">
                <input className="form-check-input" type="checkbox" onChange={() => setArchived(!archived)} checked={archived} id="list-archived-input" />
                    <label className="form-check-label" htmlFor="list-archived-input">
                        Archive
                    </label>
            </div>
            <Error errors={errors}/>
            <button onClick={submitHandler} type="submit" id="submit" className="btn btn-primary">Submit</button>
        </form>
        )

}