import axios from "axios";
import React, { useContext, useState } from "react";
import { serverLink } from "../main";
import toast from "react-hot-toast";
import { AppContext } from "../components/AppContextProvider";
import { Navigate, Link as ReactRouterLink } from "react-router-dom";

import {
  Flex,
  Box,
  FormControl,
  FormLabel,
  Input,
  InputGroup,
  HStack,
  InputRightElement,
  Stack,
  Button,
  Heading,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { ViewIcon, ViewOffIcon } from "@chakra-ui/icons";

export default function Register() {
    const [fname, setFirstName] = useState("");
    const [lname, setLastName] = useState("");
    const [accountemail, setEmail] = useState("");
    const [account, setAccount] = useState("");
    const [accountpassword, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const { setIsAuth, isAuth, loading, setIsLoading } = useContext(AppContext);

    const {setUserName } = useContext(AppContext);

    const handleForm = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        try {
            const { data } = await axios.post(
                `${serverLink}/account/register`,
                {
                    firstname: fname,
                    lastname: lname,
                    email: accountemail,
                    username: account,
                    password: accountpassword,
                },
                {
                    headers: {
                        "Content-Type": "application/json",
                    },
                }
            );
            setIsAuth(true);
            toast.success(data.message);
            setUserName(account);
            setFirstName("");
            setLastName("");
            setAccount("");
            setEmail("");
            setPassword("");
            setIsLoading(false);
        } catch (error) {
            console.log("error:", error);
            setIsAuth(false);
            toast.error(error.response.data.message);
            setIsLoading(false);
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
                    <Heading fontSize={"4xl"} textAlign={"center"}>
                        Account Registration
                    </Heading>
                </Stack>
                <Box
                    rounded={"lg"}
                    bg={useColorModeValue("white", "gray.700")}
                    boxShadow={"lg"}
                    p={8}
                >
                    <Stack spacing={4}>
                        <HStack>
                            <Box>
                                <FormControl isRequired>
                                    <FormLabel>First Name</FormLabel>
                                    <Input
                                        type="text"
                                        value={fname}
                                        onChange={(e) => setFirstName(e.target.value)}
                                    />
                                </FormControl>
                            </Box>
                            <Box>
                                <FormControl>
                                    <FormLabel>Last Name</FormLabel>
                                    <Input
                                        type="text"
                                        value={lname}
                                        onChange={(e) => setLastName(e.target.value)}
                                    />
                                </FormControl>
                            </Box>
                        </HStack>
                        <FormControl id="email" isRequired>
                            <FormLabel>Email address</FormLabel>
                            <Input
                                type="email"
                                value={accountemail}
                                onChange={(e) => setEmail(e.target.value)}
                            />
                        </FormControl>
                        <HStack>
                            <Box>
                                <FormControl id="account" isRequired>
                                    <FormLabel>Account</FormLabel>
                                    <Input
                                        type="text"
                                        value={account}
                                        onChange={(e) => setAccount(e.target.value)}
                                    />
                                </FormControl>
                            </Box>
                            <Box>
                        <FormControl isRequired>
                            <FormLabel>Password</FormLabel>
                            <InputGroup>
                                <Input
                                    type={showPassword ? "text" : "password"}
                                    value={accountpassword}
                                    onChange={(e) => setPassword(e.target.value)}
                                />
                                <InputRightElement h={"full"}>
                                    <Button
                                        variant={"ghost"}
                                        onClick={() =>
                                            setShowPassword((showPassword) => !showPassword)
                                        }
                                    >
                                        {showPassword ? <ViewIcon /> : <ViewOffIcon />}
                                    </Button>
                                </InputRightElement>
                            </InputGroup>
                            </FormControl>
                        </Box></HStack>
                        <Stack spacing={10} pt={2}>
                            <Button
                                loadingText="Submitting"
                                size="lg"
                                bg={"blue.400"}
                                color={"white"}
                                _hover={{
                                    bg: "blue.500",
                                }}
                                isDisabled={loading ? true : false}
                                onClick={handleForm}
                            >
                                Sign up
                            </Button>
                        </Stack>
                        <Stack pt={6}>
                            <Text align={"center"}>
                                Already have an account?{" "}
                                <ReactRouterLink color={"blue.400"} to="/login">
                                    Log In
                                </ReactRouterLink>
                            </Text>
                        </Stack>
                    </Stack>
                </Box>
            </Stack>
        </Flex>
    );
}
