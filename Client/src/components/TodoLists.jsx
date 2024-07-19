import React from "react";
import {
  Table,
  Thead,
  Tbody,
  Tfoot,
  Tr,
  Th,
  Td,
  TableContainer,
  Input,
} from "@chakra-ui/react";

function TodoLists({
    title,
    owner,
    description,
    taskstatus,
    startdate,
    duedate,
    isCompleted,
    updateHandler,
    deleteHandler,
    id,
}) {
    return (
        <Tbody>
            <Tr>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{title}</Td>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{description}</Td>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{owner}</Td>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{taskstatus}</Td>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{startdate}</Td>
                <Td textDecoration={isCompleted ? "line-through" : "none"}>{duedate}</Td>

                <Td>
                    {" "}
                    <button onClick={() => deleteHandler(id)} >
                        Delete
                    </button>
                </Td>
            </Tr>
        </Tbody>
    );
}

export default TodoLists;
