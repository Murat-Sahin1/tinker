import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  mode: "light"
};

export const generalSlice = createSlice({
  name: "general", 
  initialState,
  reducers: {
    setMode: (state) => {
      state.mode = state.mode === "light" ? "dark" : "light";
    },
  },
});

export const { setMode } = generalSlice.actions;
export default generalSlice.reducer;
