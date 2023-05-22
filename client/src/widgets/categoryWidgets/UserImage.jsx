import { Padding } from "@mui/icons-material";
import { Box } from "@mui/material";

const UserImage = ({ image, userId, size = "150px" }) => {
  return (
    <Box
      width={size}
      height={size}
      sx={{ "&:hover": { cursor: "pointer" }, padding: "5rem" }}
    >
      <img
        style={{ objectFit: "cover" }}
        width={size}
        height={size}
        alt="user"
        src="https://images.emojiterra.com/twitter/v13.1/512px/1f916.png"
      />
    </Box>
  );
};
export default UserImage;
