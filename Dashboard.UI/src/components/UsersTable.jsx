import React, { useState } from "react";
import UserService from "../API/UserService";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

const UsersTable = () => {
    const [users, setUsers] = useState([]);

    const [user, setUser] = useState({ userId: '', dateRegistration: '', dateLastActivity: '' })

    const [counter, setCounter] = useState(1);

    const addNewUser = (e) => {
        const newUser = {
            ...user
        }
        setUsers([...users, newUser])
        setUser({ userId: '', dateRegistration: '', dateLastActivity: '' })
        setCounter(parseInt(user.userId) + 1);
        console.log("user created")
    }

    const postUsers = () => {
        UserService.postUsers(users)
        setUsers([])
    }

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>UserID</th>
                        <th>Date Registration</th>
                        <th>Date Last Activity</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((u, i) => (
                        <tr key={i}>
                            <td>
                                {u.userId}
                            </td>
                            <td>
                                {u.dateRegistration.toString()}
                            </td>
                            <td>
                                {u.dateLastActivity.toString()}
                            </td>
                        </tr>))
                    }
                    <tr key={'new_user'}>
                        <td>
                            <MyInput
                                value={user.userId}
                                onChange={e => setUser({ ...user, userId: e.target.value })}
                                type='number'
                                placeholder={counter}
                            />
                        </td>
                        <td>
                            <MyInput
                                value={user.dateRegistration}
                                onChange={e => setUser({ ...user, dateRegistration: e.target.value })}
                                type='date'
                            />
                        </td>
                        <td>
                            <MyInput
                                value={user.dateLastActivity}
                                onChange={e => setUser({ ...user, dateLastActivity: e.target.value })}
                                type='date'
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
            <MyButton onClick={addNewUser}>Create user</MyButton>
            <MyButton onClick={postUsers}>Save</MyButton>
        </div>
    );
}

export default UsersTable;