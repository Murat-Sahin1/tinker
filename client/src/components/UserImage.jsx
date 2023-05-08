import { Box } from "@mui/material";

const UserImage = ({ image, userId, size = "60px" }) => {

    return (
      <Box
        width={size}
        height={size}
        sx={{ "&:hover": { cursor: "pointer" } }}
        onClick={() => {/* Navigate Here */}}
      >
        <img
          style={{ objectFit: "cover", borderRadius: "50%" }}
          width={size}
          height={size}
          alt="user"
          src={image}
        />
      </Box>
    );
  };
  
  export default UserImage;
  