import React, {useCallback, useContext, useEffect, useState} from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import { useNavigate } from "react-router-dom";
import { Error } from "../Error";
import { TokenContext } from "../../App";

import './Create.css'
import {useParams} from "react-router-dom";
import {readItem, updateItem} from "./itemOperations";

export function EditItem(){
    let { list_id, item_id } = useParams();
    let navigate = useNavigate()
    const statuses = ["Not started", "In process", "Completed"];
    const [title, setTitle] = useState("Default")
    const [description, setDescription] = useState("")
    const [status, setStatus] = useState(0)
    const [reminded, setReminded] = useState(false)
    const [deadline, setDeadline] = useState("")
    const [item, setItem] = useState( {})
    const [errors, setErrors] = useState([])
    const [hidden, setHidden] = useState(false)
    const [priority, setPriority] = useState(false)
    const { token, getReminded } = useContext(TokenContext);

    const getItem = useCallback(async () => {
    await readItem(item_id, token)
        .then(async (response) => {
            if (response.status === 401){
                navigate("/login")
            }
            else if (response.status === 404){
                navigate("/notFound")
            }
            else if (response.status === 500){
                navigate("/error")
            }
            else{
                let data = await response.json()
                if (parseInt(list_id) !== data.toDoListID){
                    navigate("/notFound")
                }
                setItem(data)
                setTitle(data.title);
                setHidden(data.isHidden)
                setDescription(data.description);
                setStatus(data.status)
                setReminded(data.remind)
                setPriority(data.starred)
                setDeadline(data.deadline.split(":")[0] + ":" + data.deadline.split(":")[1])
            }
            
        })
    }, [setDeadline, setStatus, setDescription, setHidden, setTitle, setItem, navigate, token, item_id, list_id])

    useEffect(() =>{
        getItem().then();
    }, [getItem])

    async function sendData(e){
        e.preventDefault()
        let data = {
            id: parseInt(item_id),
            title: title,
            description: description,
            deadline: deadline,
            createdAt: item.createdAt,
            status: status,
            isHidden: hidden,
            remind: reminded,
            priority: priority,
            toDoListID: item.toDoListID
        }

        await updateItem(data, token).then(async (response) => {
            if (response.status === 401){
                navigate("/login")
            }
            else if (response.ok){
                await getReminded()
                navigate(-1)
            }
            else if (response.status === 400){
                let data = await response.json()
                setErrors(data.errors.Title)
            }
            else if (response.status === 500){
                navigate("/error")
            }
        })
    }

        return (
            <form>
        <div className="form-group">
          <label htmlFor="todo-entry-title">Title</label>
          <input type="text" className="form-control" id="todo-entry-title" placeholder="Enter title"
                 onChange={e => setTitle(e.target.value)} value={title}/>
        </div>
        <div className="form-group">
            <label htmlFor="todo-entry-description">Description</label>
            <textarea className="form-control" id="todo-entry-description" placeholder="Enter description"
                      onChange={e => setDescription(e.target.value)} value={description}></textarea>
        </div>
        <div className="form-group">
            <div className="input-group">
                <div className="form-group">
                    <label htmlFor="deadline-input">Deadline</label>
                    <input type="datetime-local" className="form-control" id="deadline-input"
                           onChange={e => setDeadline(e.target.value)} value={deadline}/>
                </div>
                <Dropdown className="btn-group">
                    <Dropdown.Toggle type="button" className="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    {statuses[status]}
                    </Dropdown.Toggle>
                    <Dropdown.Menu className="dropdown-menu">
                        <Dropdown.Item className="dropdown-item" onClick={e => setStatus(0)} active={status === 0} href="#">Not started</Dropdown.Item>
                        <Dropdown.Item className="dropdown-item" onClick={e => setStatus(1)} active={status === 1} href="#">In process</Dropdown.Item>
                        <Dropdown.Item className="dropdown-item" onClick={e => setStatus(2)} active={status === 2} href="#">Completed</Dropdown.Item>
                    </Dropdown.Menu>
                </Dropdown>
            </div>
        </div>
        <div className="form-group">
                    <input className="form-check-input" type="checkbox" onChange={() => setPriority(!priority)} checked={priority} id="item-priority-input" />
                    <label className="form-check-label" htmlFor="item-priority-input">
                        High priority
                    </label>
                </div>
                <div className="form-group">
                    <input className="form-check-input" type="checkbox" onChange={() => setReminded(!reminded)} checked={reminded} id="item-reminded-input" />
                    <label className="form-check-label" htmlFor="item-reminded-input">
                        Reminded
                    </label>
                </div>
                <div className="form-group">
                    <input className="form-check-input" type="checkbox" onChange={() => setHidden(!hidden)} checked={hidden} id="item-hidden-input" />
                    <label className="form-check-label" htmlFor="list-archived-input">
                        Hidden
                    </label>
                </div>
                <Error errors={errors}/>
        <button type="submit" id="submit" onClick={e => sendData(e)} className="btn btn-primary">Submit</button>
      </form>
        )
}