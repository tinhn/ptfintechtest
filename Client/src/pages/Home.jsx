import React, { useContext, useEffect, useState } from "react";
import axios from "axios";
import { serverLink } from "../main";
import { toast } from "react-hot-toast";
import TodoLists from "../components/TodoLists";
import { AppContext } from "../components/AppContextProvider";
import { Form, Navigate } from "react-router-dom";

import {
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  TableContainer,
  Input,
} from "@chakra-ui/react";

function Home() {
    const [tasktitle, setTitle] = useState("");
    const [taskdescription, setDescription] = useState("");
    const [loading, setLoading] = useState(false);
    const [userTasks, setUserTasks] = useState([]);
    const [refresh, setRefresh] = useState(false);
    const { setIsAuth, isAuth } = useContext(AppContext); 
    const { userName } = useContext(AppContext); 

    const updateHandler = async (id) => {
        try {
            const { data } = await axios.put(
                `${serverLink}/task/${id}`,
                {},
                {
                    
                }
            );
            toast.success(data.message);
            setRefresh((prev) => !prev);
        } catch (error) {
            console.log("error:", error);
            toast.error(error.response.data.message);
        }
    };

    const deleteHandler = async (id) => {
        try {
            const { data } = await axios.delete(`${serverLink}/task/${id}`, {
                
            });

            toast.success(data.message);
            setRefresh((prev) => !prev);
        } catch (error) {
            console.log("error:", error);
            toast.error(error.response.data.message);
        }
    };

    const handleForm = async (e) => {
        e.preventDefault();
        setLoading(true);
        try {
            const { data } = await axios.post(
                `${serverLink}/task/addTask`,
                {
                    title:tasktitle,
                    description: taskdescription,
                    createdBy: userName
                },
                {
                    headers: {
                        "Content-Type": "application/json",
                    },
                }
            );
            setLoading(false);
            toast.success(data.message);
            setTitle("");
            setDescription("");
            setRefresh((prev) => !prev);
        } catch (error) {
            console.log("error:", error);
            toast.error(error.response.data.message);
        }
    };

    const getAllTask = async () => {        
        try {
            let { data } = await axios.get(`${serverLink}/task/gettask?username=${userName}`, {

            });
            setUserTasks(data.userTasks);
        } catch (error) {
            console.log("error:", error);
            toast.error(error.response.data.message);
        }
    };

    useEffect(() => {
        getAllTask();
    }, [refresh]);

    if (!isAuth) return <Navigate to="/login" />;

    return (        
        <div>            
            <form onSubmit={handleForm}>                
                <input
                    type="text"
                    placeholder="Title"
                    value={tasktitle}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Description"
                    value={taskdescription}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <button type="submit">ADD TASK</button>
            </form>

            <div className="sub-Container" style={{ boder: "2px solid red" }}>
                <TableContainer>
                    <Table variant="simple" width={"80%"} m={"auto"} mt={"2rem"}>
                        <Thead bg="blue.600">
                            <Tr>
                                <Th color="white">Title</Th>
                                <Th color="white">Description</Th>
                                <Th color="white">Owner</Th>
                                <Th color="white">Status</Th>
                                <Th color="white">StartDate</Th>
                                <Th color="white">DueDate</Th>
                                <Th color="white">Deltete</Th>
                            </Tr>
                        </Thead>

                        {userTasks?.map((task) => {
                            return (
                                <TodoLists
                                    key={task.id}
                                    title={task.title}
                                    owner={task.createdBy}
                                    description={task.description}
                                    taskstatus={task.taskStatus}
                                    startdate={task.startDate}
                                    duedate={task.dueDate}
                                    updateHandler={updateHandler}
                                    deleteHandler={deleteHandler}
                                    id={task.id}
                                />
                            );
                        })}
                    </Table>
                </TableContainer>
            </div>
        </div>
    );
}

export default Home;
