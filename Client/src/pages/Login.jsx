import axios from "axios";
import React, { useContext, useState } from "react";
import { Link as ReactRouterLink, Navigate } from "react-router-dom";
import { AppContext } from "../components/AppContextProvider";
import { toast } from "react-hot-toast";
import { serverLink } from "../main";

import {
  Flex,
  Box,
  FormControl,
  FormLabel,
  Input,
  Checkbox,
  Stack,
  Button,
  Heading,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";

export default function Login() {
    const [email, setEmail] = useState("");
    const [userlogin, setAccountLogin] = useState("");
    const [userPassword, setPassword] = useState("");
    const { setIsAuth, isAuth, setIsLoading, loading, setUserName } = useContext(AppContext);
    
    const handleForm = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        try {
            const { data } = await axios.post(
                `${serverLink}/account/login`,
                {
                    username: userlogin,
                    password: userPassword
                },
                {
                    headers: {
                        "Content-Type": "application/json",
                    }
                }
            );
            console.log(data);
            toast.success(data.message);
            setUserName(userlogin);
            setIsAuth(true);
            setEmail("");
            setAccountLogin("");
            setPassword("");
            setIsLoading(false);
        } catch (error) {
            console.log(error);
            toast.error("something went wrong");
            setIsLoading(false);
            setIsAuth(false);
        }
    };

    if (isAuth) return <Navigate to="/" />;

    return (
        <Flex
            minH={"100vh"}
            align={"center"}
            justify={"center"}
            bg={useColorModeValue("gray.50", "gray.800")}
        >
            <Stack spacing={8} mx={"auto"} maxW={"lg"} py={12} px={6}>
                <Stack align={"center"}>
                    <Heading fontSize={"4xl"}>Sign in</Heading>
                    <Text fontSize={"lg"} color={"gray.600"}>
                        to add your task
                    </Text>
                </Stack>
                <Box
                    rounded={"lg"}
                    bg={useColorModeValue("white", "gray.700")}
                    boxShadow={"lg"}
                    p={8}
                >
                    <Stack spacing={4}>
                        <FormControl id="username">
                            <FormLabel>Account</FormLabel>
                            <Input
                                type="text"
                                value={userlogin}
                                required
                                onChange={(e) => setAccountLogin(e.target.value)}
                            />
                        </FormControl>
                        <FormControl id="password">
                            <FormLabel>Password</FormLabel>
                            <Input
                                type="current-password"
                                value={userPassword}
                                required
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </FormControl>
                        <Stack spacing={10}>                            
                            <Button
                                bg={"blue.400"}
                                color={"white"}
                                _hover={{
                                    bg: "blue.500",
                                }}
                                isDisabled={loading ? true : false}
                                onClick={handleForm}
                            >
                                Sign in
                            </Button>
                        </Stack>

                        <Stack pt={6}>
                            <Text align={"center"}>
                                No account?{" "}
                                <ReactRouterLink color={"blue.400"} to="/register">
                                    Register now
                                </ReactRouterLink>
                            </Text>
                        </Stack>
                    </Stack>
                </Box>
            </Stack>
        </Flex>
    );
}
